using System;
using System.Collections.Generic;
using System.IO;

namespace ContactApplicationFile
{
    public class ContactRepository
    {
        public List<ContactEntity> Contacts = new List<ContactEntity>();
        public ContactRepository()
        {
            FetchContactInfoFromFile();
        }
        public void FetchContactInfoFromFile()
        {
            try
            {
                var contactInfoLines = File.ReadAllLines("My-Contact-List.txt");
                foreach (var contactInfoLine in contactInfoLines)
                {
                    var contact = ContactEntity.StringToContactEntity(contactInfoLine);
                    Contacts.Add(contact);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintContacts(ContactEntity contact)
        {
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone Number: {contact.PhoneNumber}, Email: {contact.Email},  Office Address: {contact.OfficeAddress} ");
        }
        public void GetContactsInfo()
        {
            foreach (ContactEntity contact in Contacts)
            {
                PrintContacts(contact);
            }
        }
        public List<ContactEntity> ListContactsInfo()
        {
            return Contacts;
        }

        public void AddContactInfo(int id, string name, string phoneNumber, string email, string officeAddress)
        {
            var contactExist = FindContactById(id);

            if (contactExist != null)
            {
                Console.WriteLine($"Contact with {id} already exist");
            }

            else
            {
                ContactEntity contact = new ContactEntity(id, name, phoneNumber, email, officeAddress);

                Contacts.Add(contact);

                TextWriter writer = new StreamWriter("My-Contact-List.txt", true);
                writer.WriteLine(contact.ToString());
                Console.WriteLine("Contact added successfully!");
                writer.Close();
            }
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("My-Contact-List.txt");
            foreach (var contact in Contacts)
            {
                writer.WriteLine(contact);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteContactInfo(int id)
        {
            var contact = FindContactById(id);

            if (contact == null)
            {
                Console.WriteLine($"Student with id {id} does not exist");
            }

            Contacts.Remove(contact);
            RefreshFile();
        }



        public ContactEntity FindContactById(int id)
        {
            return Contacts.Find(s => s.Id == id);
        }

        public List<ContactEntity> FindContactByName(string name)
        {
            return Contacts.FindAll(c => c.Name == name);
        }
        public void FindContact()
        {
            Console.WriteLine("Enter the id of the Contact you want to find: ");
            int id = int.Parse(Console.ReadLine());

            var contact = FindContactById(id);

            if (contact == null)
            {
                Console.WriteLine($"Student with Email \t {id} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Id: {contact.Id} Name: {contact.Name}  Phone Number: {contact.PhoneNumber} Email: {contact.Email} Office Address: {contact.OfficeAddress} ");
            }
        }
        public void ListAllContacts()
        {
            {
                foreach (var contact in Contacts)
                {
                    Console.WriteLine($"Id: {contact.Id} Name: {contact.Name}  Phone Number: {contact.PhoneNumber} Email: {contact.Email} Office Address: {contact.OfficeAddress} ");
                }
            }
        }

        public void FindContactName()
        {
            Console.WriteLine("Enter the name of the Contact you want to find: ");
            string name = Console.ReadLine();

            var contact = FindContactByName(name);

            if (contact == null)
            {
                Console.WriteLine($"Student with Name {name} does not exist! ");
            }

            else
            {
                // if(contact.Exists())
                // Console.WriteLine($"Name: {contact.Contains(name)} "); 
            }

        }

        public void UpdateContact(int id, string name, string phoneNumber, string email, string officeAddress)
        {


            var contact = FindContactById(id);

            if (contact == null)
            {
                Console.WriteLine($"Student with {id} does not exist");
            }

            else
            {
                contact.Name = name;
                contact.Email = email;
                contact.PhoneNumber = phoneNumber;
                contact.OfficeAddress = officeAddress;
            }

        }
    }
}