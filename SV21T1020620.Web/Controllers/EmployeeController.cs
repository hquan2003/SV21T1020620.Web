﻿using Microsoft.AspNetCore.Mvc;
using SV21T1020620.BusinessLayers;
using SV21T1020620.DomainModels;

namespace SV21T1020620.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private const int PAGE_SIZE = 12;
        public IActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount;
            var data = CommonDataService.ListOfEmployees(out rowCount, page, PAGE_SIZE, searchValue ?? "");

            int pageCount = rowCount / PAGE_SIZE;
            if (rowCount % PAGE_SIZE > 0)
                pageCount += 1;

            ViewBag.Page = page;
            ViewBag.RowCount = rowCount;
            ViewBag.PageCount = pageCount;
            ViewBag.SearchValue = searchValue;

            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Bổ sung nhân viên mới";
            var data = new Employee()
            {
                EmployeeID = 0,
                IsWorking = true
            };
            return View("Edit", data);
        }
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Cập nhật thông tin nhân viên";
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }
        public IActionResult Save(Employee data)
        {
            //TODO: Kiểm soát dữ liệu đầu vào
            if (data.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(data);
            }
            else
            {
                CommonDataService.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id = 0)
        {
            if (Request.Method == "POST")
            {
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");

            return View(data);
        }
       
    }
}
