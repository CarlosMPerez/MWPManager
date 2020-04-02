using System;
using System.IO;
using System.Windows.Forms;

namespace MWPManager
{
    public partial class Main : Form
    {
        public enum Icons
        {
            HardDrive = 0,
            FolderClosed = 1,
            FolderOpen = 2,
            ImageFile = 3
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach(DriveInfo drive in drives)
            {
                rootNode = new TreeNode(drive.Name, (int)Icons.HardDrive, (int)Icons.HardDrive);
                rootNode.Tag = drive;
                tvFolders.Nodes.Add(rootNode);
                GetFolders(drive.RootDirectory.GetDirectories(), rootNode);
                GetFiles(drive);
            }
        }

        private void GetFolders(DirectoryInfo[] rootDirs, TreeNode parentNode)
        {
            TreeNode node;
            foreach(DirectoryInfo dir in rootDirs)
            {
                try
                {
                    node = new TreeNode(dir.Name, (int)Icons.FolderClosed, (int)Icons.FolderOpen);
                    node.Tag = dir;
                    // Cogemos sólo el primer nivel de subdirectorios, no queremos recursión para no eternizar la carga
                    if (dir.GetDirectories().Length > 0)
                    {
                        node.Nodes.Clear();
                        foreach(DirectoryInfo sub in dir.GetDirectories())
                        {
                            TreeNode subNode = new TreeNode(sub.Name, (int)Icons.FolderClosed, (int)Icons.FolderOpen);
                            subNode.Tag = sub;
                            node.Nodes.Add(subNode);
                        }
                    }
                    parentNode.Nodes.Add(node);
                }
                catch (UnauthorizedAccessException)
                {
                    // ignore error and keep at it
                }
            }
        }

        private void GetFiles(DirectoryInfo info)
        {
            lstFiles.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (FileInfo file in info.GetFiles())
            {
                item = new ListViewItem(file.Name, (int)Icons.ImageFile);
                lstFiles.Items.Add(item);
            }

            //lstFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void GetFiles(DriveInfo info)
        {
            lstFiles.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (FileInfo file in info.RootDirectory.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                lstFiles.Items.Add(item);
            }

            lstFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void tvFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // ignora los clicks en los controles de expandir y contraer del treeview
            TreeViewHitTestInfo hit = tvFolders.HitTest(e.Location);
            if (hit.Location != TreeViewHitTestLocations.PlusMinus)
            {
                TreeNode selectedNode = e.Node;
                selectedNode.Nodes.Clear();

                if (selectedNode.Tag.GetType() == typeof(DriveInfo))
                {
                    DriveInfo info = (DriveInfo)selectedNode.Tag;
                    GetFolders(info.RootDirectory.GetDirectories(), selectedNode);
                    GetFiles(info);
                }
                else if (selectedNode.Tag.GetType() == typeof(DirectoryInfo))
                {
                    DirectoryInfo info = (DirectoryInfo)selectedNode.Tag;
                    GetFolders(info.GetDirectories(), selectedNode);
                    GetFiles(info);
                }

                selectedNode.Expand();
            }
        }
    }
}
