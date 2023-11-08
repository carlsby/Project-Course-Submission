using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using Project_Course_Submission.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Net;

public class MyAddressController : Controller
{
    private readonly IdentityContext _context;

    public MyAddressController(IdentityContext context)
    {
        _context = context;
    }


    [Authorize]


    public IActionResult Index()
    {
        string loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(loggedInUserId))
        {

            return RedirectToAction("Login");
        }

        var userAddresses = _context.UserAddress
            .Where(ua => ua.UserId == loggedInUserId)
            .Select(ua => ua.Address)
            .ToList();

        var addresses = userAddresses.Select(ua => new Address
        {
            Id = ua.Id,
            Type = ua.Type,
            City = ua.City,
            StreetName = ua.StreetName,
            PostalCode = ua.PostalCode
        }).ToList();

        return View("Views/Partials/MyAddress/_MyAddress.cshtml", addresses);
    }


    public IActionResult AddAddress()
    {
        var AddressViewModel = new Address();
        return View("Views/Partials/MyAddress/_AddAddress.cshtml", AddressViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> SaveAddress(Address AddressViewModel)
    {


        string fullAddress = AddressViewModel.FullAddress;


        string[] addressParts = fullAddress.Split(',');

        if (addressParts.Length != 3)
        {
            ModelState.AddModelError("FullAddress", "Invalid address format. Please use 'Streetname, Postcode, City' format.");
            return View("Views/Partials/MyAddress/_AddAddress.cshtml", AddressViewModel);
        }

        string type = AddressViewModel.Type;
        string streetName = addressParts[0].Trim();
        string postalCode = addressParts[1].Trim();
        string city = addressParts[2].Trim();

        var addressEntity = new AddressEntity
        {
            Type = type,
            StreetName = streetName,
            PostalCode = postalCode,
            City = city
        };

        _context.Addresses.Add(addressEntity);
        await _context.SaveChangesAsync();


        var userAddressEntity = new UserAddressEntity
        {
            AddressId = addressEntity.Id,
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        };

        _context.UserAddress.Add(userAddressEntity);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult EditAddress(int id)
    {
        var addressEntity = _context.Addresses.Find(id);

        if (addressEntity == null)
        {
            return NotFound();
        }

        var address = new Address
        {
            Id = addressEntity.Id,
            Type = addressEntity.Type,
            StreetName = addressEntity.StreetName,
            PostalCode = addressEntity.PostalCode,
            City = addressEntity.City,
            FullAddress = addressEntity.FullAddress
        };

        return View("Views/Partials/MyAddress/_EditAddress.cshtml", address);
    }
    [HttpPost]
    public IActionResult EditAddress(Address address)
    {
        if (!ModelState.IsValid)
        {

            var addressEntity = _context.Addresses.Find(address.Id);

            if (addressEntity == null)
            {
                return NotFound();
            }

            addressEntity.Type = address.Type;
            addressEntity.StreetName = address.StreetName;
            addressEntity.PostalCode = address.PostalCode;
            addressEntity.City = address.City;

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        return View("Views/Partials/MyAddress/_EditAddress.cshtml", address);
    }
}


