using PGtraining.Lib.DB;
using PGtraining.Lib.Setting;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace PGtraining.RisMenu.Model
{
    public class WorkListModel : BindableBase
    {
        public ObservableCollection<OrderModel> WorkList { get; } = new ObservableCollection<OrderModel>();
        private Setting Setting = null;

        public WorkListModel(Setting setting)
        {
            this.Setting = setting;
            this.SetWorkList();
        }

        public void SetWorkList()
        {
            var orders = Sql.GetOrders(this.Setting);

            this.WorkList.AddRange(orders.Select(x => new OrderModel(x)));
        }
    }
}