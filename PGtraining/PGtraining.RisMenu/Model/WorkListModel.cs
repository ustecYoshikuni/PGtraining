using PGtraining.Lib.DB;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace PGtraining.RisMenu.Model
{
    public class WorkListModel : BindableBase
    {
        public ObservableCollection<OrderModel> WorkList { get; } = new ObservableCollection<OrderModel>();

        public WorkListModel()
        {
            this.SetWorkList();
        }

        public void SetWorkList()
        {
            var orders = Sql.GetOrders();

            this.WorkList.AddRange(orders.Select(x => new OrderModel(x)));
        }
    }
}