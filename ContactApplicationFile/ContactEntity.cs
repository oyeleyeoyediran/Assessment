using System;
namespace ContactApplicationFile
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OfficeAddress { get; set; }

        public ContactEntity(int id, string name, string phoneNumber, string email, string officeAddress)
        {
            Id = id;

            Name = name;

            PhoneNumber = phoneNumber;

            Email = email;

            OfficeAddress = officeAddress;
        }
        
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{PhoneNumber}\t{Email}\t{OfficeAddress} ";
        }

        internal static ContactEntity StringToContactEntity(string contactString)
        {
            var props = contactString.Split("\t");

            int id = int.Parse(props[0]);

            string name = props[1];

            string phoneNumber = props[2];

            string email = props[3];

            string officeAddress = props[4];

            return new ContactEntity(id, name, phoneNumber, email,  officeAddress);
        }
    }

}