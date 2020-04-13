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
            ListViewItem item = null;

            foreach (FileInfo file in info.GetFilesByExtensions())
            {
                item = new ListViewItem(file.Name, (int)Icons.ImageFile);
                item.Tag = file.FullName;
                lstFiles.Items.Add(item);
            }

            lstFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
                    GetFiles(info.RootDirectory);
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

        /// <summary>
        /// Cargamos la imagen seleccionada en el control de imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ctl = (ListView)sender;
            if (ctl.SelectedItems.Count > 0)
            {
                picWP.ImageLocation = ctl.SelectedItems[0].Tag.ToString();
            }
        }
    }
}
