using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Diagnostics;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Project_Course_Submission.Services;

public interface ITwilioService
{
    Task<ServiceResponse<PhoneNumberViewModel>> SendTextVerification(PhoneNumberViewModel phoneNumberViewModel);
}

public class TwilioService : ITwilioService
{
    public async Task<ServiceResponse<PhoneNumberViewModel>> SendTextVerification(PhoneNumberViewModel phoneNumberViewModel)
    {
        var response = new ServiceResponse<PhoneNumberViewModel>();

        try
        {
            string accountSid = "AC4857a3b575c88d6b68bc6c7bdccd844d";
            string authToken = "0313e76f8b491c7d32133bb6472d15e7";

            TwilioClient.Init(accountSid, authToken);
            string fromPhoneNumber = "+13202868756";

            var messageBody = GenerateUniqueRandomNumbers(1, 0, 9999);

            string body = string.Join(" ", messageBody);

            string toPhoneNumber = phoneNumberViewModel.PhoneNumber!;
            MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            response.StatusCode = Enums.StatusCode.Ok;
        }
        catch (Exception ex)
        {
            response.StatusCode = Enums.StatusCode.BadRequest;
            Debug.WriteLine(ex);
        }

        return response;
    }

    private List<int> GenerateUniqueRandomNumbers(int count, int minValue, int maxValue)
    {
        var random = new Random();
        var uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = random.Next(minValue, maxValue + 1);
            uniqueNumbers.Add(randomNumber);
        }

        return uniqueNumbers.ToList();
    }
}
