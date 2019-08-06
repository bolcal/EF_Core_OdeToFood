using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {   
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1, Name="Emre's Pizza",Address="Göztepe",Cuisine =CuisineType.Italian},
                new Restaurant {Id=2, Name="Emre's Ev",Address="Acibadem",Cuisine =CuisineType.Mexican},
                new Restaurant {Id=3, Name="Indian Chef",Address="Suadiye",Cuisine =CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id)+1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant !=null)
            {
                restaurant.Address = updatedRestaurant.Address;
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
                restaurants.Remove(restaurant);

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetRestaurantCount()
        {
            return restaurants.Count();
        }
    }
}
