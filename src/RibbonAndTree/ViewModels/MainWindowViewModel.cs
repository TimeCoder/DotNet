using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;
using Catel.MVVM.Services;
using RibbonAndTree.Models;

namespace RibbonAndTree.ViewModels
{
    using Catel.MVVM;
    
    
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IMessageService messageService)
        {
            
        }

        public IEnumerable<Node> TreeData
        {
            get
            {
                var list = new List<Node>
                {
                    new Node {Id = 1, Name = "Parent", ParentId = 0},

                    new Node {Id = 2, Name = "Child1", ParentId = 1},
                    new Node {Id = 3, Name = "Child2", ParentId = 1},

                    new Node 
                    {
                        Id = 3, 
                        Name = "ChildOfChild", 
                        ParentId = 2, 
                        Data = new List<DataItem>
                        {
                            new DataItem {Name = "Test 1", Age = 1},
                            new DataItem {Name = "Test 2", Age = 2},
                        }
                    },
                };

                list.ForEach(node => node.Owner = list);

                return list;
            }
        }


        private void GenerateTree()
        {
            
        }
    }
}
