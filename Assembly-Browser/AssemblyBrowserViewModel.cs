﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AssemblyBrowserLibrary;

namespace Assembly_Browser
{
    public class AssemblyBrowserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public AssemblyBrowserViewModel() { }

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                return _openCommand ??
                    (_openCommand = new RelayCommand((obj) => {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Title = "Select Assembly";
                        openFileDialog.Filter = "Assembly|*.dll";
                        if (openFileDialog.ShowDialog() == true)
                        {
                            FilePath = openFileDialog.FileName;
                        }
                        if (FilePath != null)
                        {
                            AssemblyBrowserModel assemblyBrowser = new AssemblyBrowserModel();
                            Namespaces = new ObservableCollection<Namespace>(assemblyBrowser.LoadAssembly(FilePath));
                        }
                    }));
            }
        }

        private ObservableCollection<Namespace> _namespaces { get; set; }
        public ObservableCollection<Namespace> Namespaces
        {
            get
            {
                return _namespaces;
            }
            set
            {
                _namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }
    }
}
