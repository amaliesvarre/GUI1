using System;
using System.Windows.Input;
using SparePartsInventory.Models;

namespace SparePartsInventory.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public OrderBook Book { get; } = new();

        public System.Collections.ObjectModel.ObservableCollection<Order> QueuedOrders
            => Book.QueuedOrders;
        public System.Collections.ObjectModel.ObservableCollection<Order> ProcessedOrders
            => Book.ProcessedOrders;

        private decimal _totalRevenue;
        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set => SetProperty(ref _totalRevenue, value);
        }

        public ICommand ProcessNextCommand { get; }

        public MainWindowViewModel()
        {
            // Demo-data (tre ordrer)
            Book.Queue(new Order(
                new OrderLine("Bolt M6", 0.80m, 50),
                new OrderLine("Pen",     2.50m,  5)));

            Book.Queue(new Order(
                new OrderLine("Cable (m)", 15.90m, 3),
                new OrderLine("Washer",     0.20m, 40)));

            Book.Queue(new Order(
                new OrderLine("Pellets (kg)", 3.20m, 4)));

            ProcessNextCommand = new RelayCommand(_ => ProcessNext());
        }

        private void ProcessNext()
        {
            var next = Book.Dequeue();
            if (next is null) return;

            Book.AddProcessed(next);
            TotalRevenue = Book.TotalRevenue();
        }
    }

    // Minimal ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _exec;
        private readonly Func<object?, bool>? _can;
        public RelayCommand(Action<object?> exec, Func<object?, bool>? can = null)
        { _exec = exec; _can = can; }

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? p) => _can?.Invoke(p) ?? true;
        public void Execute(object? p) => _exec(p);
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
