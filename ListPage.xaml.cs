using System;
using CiciovanBogdanIonutLab7.Models;
using Microsoft.Maui.Controls;

namespace CiciovanBogdanIonutLab7
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopList = (ShopList)this.BindingContext;
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var shopList = (ShopList)BindingContext;
            await App.Database.SaveShopListAsync(shopList);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var shopList = (ShopList)BindingContext;
            await App.Database.DeleteShopListAsync(shopList);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            var shopList = (ShopList)this.BindingContext;
            await Navigation.PushAsync(new ProductPage(shopList)
            {
                BindingContext = new Product()
            });
        }

        async void OnDeleteItemClicked(object sender, EventArgs e)
        {
            var selectedProduct = listView.SelectedItem as Product;
            if (selectedProduct != null)
            {
                var shopList = (ShopList)this.BindingContext;
                var listProduct = await App.Database.GetListProductAsync(shopList.ID, selectedProduct.ID);
                if (listProduct != null)
                {
                    await App.Database.DeleteListProductAsync(listProduct);
                    listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
                }
            }
            else
            {
                await DisplayAlert("Error", "Please select an item to delete.", "OK");
            }
        }
    }
}
