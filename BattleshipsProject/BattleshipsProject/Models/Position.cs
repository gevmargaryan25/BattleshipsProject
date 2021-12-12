using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Battleships.Models
{
    public class Position : INotifyPropertyChanged
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int ShipType { get; set; }
        public int Direction { get; set; }
        private bool _isHit;
        public bool IsHit
        {
            get => _isHit;
            set
            {
                _isHit = value;
                OnPropertyChanged("IsHit");
            }
        }
        public bool IsDummy { get; set; }
        public int PieceOrderNumber { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}