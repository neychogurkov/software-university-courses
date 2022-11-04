namespace Telephony.Core
{
    using System;

    using Contracts;
    using Models;
    using Models.Contracts;
    using IO.Contracts;
    using Exceptions;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split();
            string[] urls = reader.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    this.writer.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidURLException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
