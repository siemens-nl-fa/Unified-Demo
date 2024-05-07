using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Siemens.Engineering;

namespace OpennessLibrary
{
    public partial class Openness
    {
        #region Fields & Properties
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }
        #endregion

        #region Methods
        #region Create
        public Project Project_Create(DirectoryInfo targetDirectory, string name)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = projects.Create(targetDirectory, name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }

        public async Task<Project> Project_Create_Async(DirectoryInfo targetDirectory, string name)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = await Task.Run(() => projects.Create(targetDirectory, name));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }
        #endregion

        #region Open
        public Project Project_Open(FileInfo path)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = projects.Open(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }

        public async Task<Project> Project_Open_Async(FileInfo path)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = await Task.Run(() => projects.Open(path));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }

        public Project Project_OpenWithUpgrade(FileInfo path)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = projects.OpenWithUpgrade(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }

        public async Task<Project> Project_OpenWithUpgrade_Async(FileInfo path)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = await Task.Run(() => projects.OpenWithUpgrade(path));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }
        #endregion

        #region Save
        public void Project_Save()
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    try
                    {
                        Project.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }

        public void Project_SaveAs(DirectoryInfo targetFolderPath)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    try
                    {
                        Project.SaveAs(targetFolderPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }

        public async Task Project_SaveAs_Async(DirectoryInfo targetFolderPath)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    try
                    {
                        await Task.Run(() => Project.SaveAs(targetFolderPath));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }
        #endregion

        #region Close
        public void Project_Close()
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    try
                    {
                        Project.Close();
                        Project = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }
        #endregion

        #region Archive
        public void Project_Archive(DirectoryInfo targetDirectory, string targetName, ProjectArchivationMode archivationMode)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    Project.Archive(targetDirectory, targetName, archivationMode);
                }
            }
        }

        public async Task Project_Archive_Async(DirectoryInfo targetDirectory, string targetName, ProjectArchivationMode archivationMode)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    await Task.Run(() => Project.Archive(targetDirectory, targetName, archivationMode));
                }
            }
        }
        #endregion

        #region Retrieve
        public Project Project_Retrieve(FileInfo sourcePath, DirectoryInfo targetDirectory)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project != null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = projects.Retrieve(sourcePath, targetDirectory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }

        public async Task<Project> Project_Retrieve_Async(FileInfo sourcePath, DirectoryInfo targetDirectory)
        {
            if (TiaPortal != null && TiaPortalProcess != null)
            {
                if (Project == null)
                {
                    try
                    {
                        ProjectComposition projects = TiaPortal.Projects;
                        Project = await Task.Run(() => projects.Retrieve(sourcePath, targetDirectory));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
            return Project;
        }
        #endregion
        #endregion
    }
}
