using C1.Win.C1Ribbon;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class RecentDocumentList
    {
        public delegate void LoadDocumentDelegate(string filename);

        public RecentDocumentList(
            RibbonItemCollection rightPaneItems,
            StringCollection files,
            LoadDocumentDelegate loadDocument)
        {
            this.rightPaneItems = rightPaneItems;
            this.files = files;
            this.loadDocument = loadDocument;

            // first create a header and make sure it's not selectable
            RibbonListItem listItem = new RibbonListItem(new RibbonLabel("Recent Documents"));
            listItem.AllowSelection = false;
            rightPaneItems.Add(listItem);
            rightPaneItems.Add(new RibbonListItem(new RibbonSeparator()));

            this.listTopIndex = rightPaneItems.Count;

            // create the recently used document list
            foreach (string document in this.files)
            {
                RecentDocumentItem item = new RecentDocumentItem(document, false, loadDocument);
                rightPaneItems.Add(item);

                string d = document;
            }
        }

        readonly RibbonItemCollection rightPaneItems;
        readonly StringCollection files;
        readonly LoadDocumentDelegate loadDocument;
        readonly int listTopIndex;

        class RecentDocumentItem : RibbonListItem
        {
            public RecentDocumentItem(string fullFileName, bool pinned, LoadDocumentDelegate loadDocument)
            {
                this.fullFileName = fullFileName;

                string documentName = new FileInfo(fullFileName).Name;

                // each item consists of the name of the document and a push pin
                this.label = new RibbonLabel(documentName);
                this.pin = new RibbonToggleButton();

                // allow the button to be selectable so we can toggle it
                this.pin.AllowSelection = true;

                this.pin.Pressed = pinned;
                this.pin.PressedChanged += delegate { this.SetPinImage(); };
                this.SetPinImage();

                this.Items.Add(this.label);
                this.Items.Add(this.pin);

                this.ToolTip = fullFileName;

                this.Click += delegate { loadDocument(this.FullFileName); };
            }

            readonly RibbonLabel label;
            readonly RibbonToggleButton pin;
            readonly string fullFileName;

            void SetPinImage()
            {
                this.pin.SmallImage = this.pin.Pressed
                    ? Properties.Resources.Pinned
                    : Properties.Resources.Unpinned;
            }

            public string FullFileName
            {
                get { return this.fullFileName; }
            }

            public bool Pinned
            {
                get { return this.pin.Pressed; }
            }
        }

        /// <summary>
        /// Adds or moves the file to the top of the list.
        /// </summary>
        /// <param name="filename"> Absolule or relative file path and name. </param>
        public void Update(string filename)
        {
            string fullFileName = new FileInfo(filename).FullName;

            int i = this.IndexOf(fullFileName);
            if (i >= 0)
            {
                if (this[i].Pinned) return; // do not move pinned items

                this.RemoveAt(i);
            }

            this.Insert(0, new RecentDocumentItem(fullFileName, false, this.loadDocument));
        }

        private int Count
        {
            get { return this.rightPaneItems.Count - this.listTopIndex; }
        }

        private RecentDocumentItem this[int i]
        {
            get { return (RecentDocumentItem)this.rightPaneItems[this.listTopIndex + i]; }
        }

        private int IndexOf(string fullFileName)
        {
            for (int i = 0; i < this.Count; ++i)
            {
                if (this[i].FullFileName == fullFileName) return i;
            }
            return -1;
        }

        private void RemoveAt(int i)
        {
            this.rightPaneItems.RemoveAt(this.listTopIndex + i);
            this.files.RemoveAt(i);
        }

        private void Insert(int i, RecentDocumentItem item)
        {
            this.rightPaneItems.Insert(this.listTopIndex + i, item);
            this.files.Insert(i, item.FullFileName);
        }
    }
}
