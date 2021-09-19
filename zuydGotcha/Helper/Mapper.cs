using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zuydGotcha.Helper
{
    public class Mapper
    {

        public static TViewModel Model<TViewModel, TModel>(TViewModel viewModel, TModel model)
        {
            var viewModelproperty = viewModel.GetType().GetProperties().Where(e => !e.GetGetMethod().IsVirtual);
            var modelproperty = model.GetType().GetProperties().Where(e => !e.GetGetMethod().IsVirtual);

            foreach (var item in modelproperty)
            {
                if (viewModelproperty.Any(e=>e.Name == item.Name))
                {
                    viewModelproperty.First(x => x.Name == item.Name).SetValue(viewModel, item.GetValue(model));
                }
            }
            return viewModel;
        }

        public static TModel ViewModel<TModel, TViewModel>(TModel Model, TViewModel viewModel)
        {
            var viewModelproperty = viewModel.GetType().GetProperties().Where(e => !e.GetGetMethod().IsVirtual);
            var modelproperty = Model.GetType().GetProperties().Where(e => !e.GetGetMethod().IsVirtual);

            foreach (var item in viewModelproperty)
            {
                if (viewModelproperty.Any(e => e.Name == item.Name))
                {
                    modelproperty.First(x => x.Name == item.Name).SetValue(viewModel, item.GetValue(Model));
                }
            }
            return Model;
        }
    }
}