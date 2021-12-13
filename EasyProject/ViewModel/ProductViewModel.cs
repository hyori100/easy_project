﻿using EasyProject.Dao;
using EasyProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;

namespace EasyProject.ViewModel
{
    public class ProductViewModel
    {
        ProductDao dao = new ProductDao();

        public ObservableCollection<CategoryModel> Categories { get; set; }

        //선택한 카테고리를 담을 프로퍼티
        public CategoryModel SelectedCategory { get; set; }
        
        //재고 입력 데이터를 담을 프로퍼티
        public ProductModel Product { get; set; }

        //로그인한 간호자(사용자) 정보를 담을 프로퍼티
        public NurseModel Nurse { get; set; }

        public ProductViewModel()
        {
            Product = new ProductModel()
            {
                Prod_expire = DateTime.Now
            };
            List<CategoryModel> list = dao.GetCategoryModels();
            Categories = new ObservableCollection<CategoryModel>(list); // List타입 객체 list를 OC 타입 Products에 넣음 
        }


        private ActionCommand command;
        public ICommand Command
        {
            get
            {
                if (command == null)
                {
                    command = new ActionCommand(ProductInsert);
                }
                return command;
            }//get

        }//Command

        public void ProductInsert()
        {
            //재고입력
            dao.AddProduct(Product, SelectedCategory);

            //입고테이블에 추가
            //dao.StoredProduct(Product, Nurse);
        }// ProductInsert

    }//class

}//namespace
