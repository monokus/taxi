﻿using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Common.Enums;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync() // This method will inject the database
        {
            await _dataContext.Database.EnsureCreatedAsync();
            //UserEntity driver = await CheckUserAsync("2020", "Juan", "Zuluaga", "jzuluaga55@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Driver);
            //erEntity user1 = await CheckUserAsync("3030", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            //UserEntity user2 = await CheckUserAsync("5050", "Camila", "Cifuentes", "camila@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            await CheckTaxisAsync();
        }

        private async Task CheckTaxisAsync()
        {
            if (!_dataContext.Taxis.Any())
            {
                _dataContext.Taxis.Add(new TaxiEntity
                {
                    //User = driver,
                    Plaque = "TPQ123",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer convallis finibus nisl in fringilla. Fusce et odio dolor. Aliquam venenatis libero tortor, at tincidunt neque auctor vitae. Morbi lobortis eget quam eget convallis. Morbi id magna neque. Pellentesque sit amet imperdiet lacus. Aliquam ac facilisis elit, in aliquet felis. Morbi lacinia nunc ut tristique ornare. Integer felis risus, tempor eu placerat vel, lacinia nec ipsum. Cras eleifend orci ac dictum lacinia. Cras id porta ex, quis interdum ex. Vivamus facilisis feugiat diam, vitae euismod quam dignissim sit amet. Integer egestas a velit sit amet auctor. Pellentesque mollis nisl in nibh viverra posuere. Nulla facilisi.",
                            //User = user1
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Donec non convallis elit. Donec ultricies, leo sed convallis ullamcorper, erat tortor mattis felis, ornare commodo dui lorem a erat. Proin suscipit varius purus sed viverra. Vestibulum vitae massa nec nunc hendrerit faucibus. Duis sit amet neque fringilla, interdum sem ac, imperdiet nisl. Maecenas ultrices justo felis, ac interdum sem facilisis ut. Aliquam et aliquam mi.",
                            //User = user1
                        }
                    }
                });

                _dataContext.Taxis.Add(new TaxiEntity
                {
                    Plaque = "THW321",
                    //User = driver,
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            //User = user2
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            //User = user2
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }

        }
    }
}