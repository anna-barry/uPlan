using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UplanTest
{
    public class InfoResponseApi
    {
        public static async Task<FoodModel> LoadInfo(string codeBarre)
        {

            string url = $"https://world.openfoodfacts.org/api/v0/product/{ codeBarre }.json";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FoodResultModel food = await response.Content.ReadAsAsync<FoodResultModel>();

                    return food.Product;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}