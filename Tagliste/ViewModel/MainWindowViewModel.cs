using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagliste.Model;

namespace Tagliste.ViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<Tag> Tags { get; set; }

        public MainWindowViewModel()
        {
            Tags = new ObservableCollection<Tag>
            {
            new Tag{Name = "qwe", Description = "123", Type = "string"},
            new Tag{Name = "asd", Description = "456", Type = "bool"},
            new Tag{Name = "zxc", Description = "789", Type = "string"},
            new Tag{Name = "rty", Description = "246", Type = "int"},
            new Tag{Name = "fgh", Description = "135", Type = "string"}
            };

        }

    }
}
