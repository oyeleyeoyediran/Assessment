using System;
using System.Collections.Generic;

namespace ContactApplicationFile
{
    public class Menu
    {
    
        static ContactRepository contactRepo = new ContactRepository();

        private void ShowMenu()
        {
            Console.WriteLine("0. Back");
            Console.WriteLine("1. Add Contact Information");
            Console.WriteLine("2. List available Contacts");
            Console.WriteLine("3. Find Contact ");
            Console.WriteLine("4. Update Contacts");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Search Contact using name");
        }

        public void AddContactDetails()
        {
            Console.Write("Enter Contact Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.AddContactInfo(id, name, phoneNumber, email, officeAddress);
        }

        public void UpdateContactDetails()
        {
            Console.Write("Enter Contact Id you want to update: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Update Contact Name: ");
            string name = Console.ReadLine();

            Console.Write("Update Contact Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Update Contact email: ");
            string email = Console.ReadLine();

            Console.Write("Update Contact Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.UpdateContact(id, name, phoneNumber, email, officeAddress);
            contactRepo.RefreshFile();
        }

        public void DeleteContact()
        {
            Console.Write("Enter of Id Contact you want to delete: ");
            int id  = int.Parse(Console.ReadLine());

            Console.Write("Are you sure you want to delete? ");
            string option = Console.ReadLine();

            if(option == "yes")
            {
                contactRepo.DeleteContactInfo(id);

                Console.WriteLine($"Contact with {id} deleted successfully! ");
            }

            else
            {
                ShowMenu();
            }
        }
        public void ShowContactMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddContactDetails();
                    ShowContactMenu();
                    break;
                case "2":
                    contactRepo.ListAllContacts();
                    ShowContactMenu();
                    break;

                case "3":
                    contactRepo.FindContact();
                    ShowContactMenu();
                    break;

                case "4":
                    UpdateContactDetails();
                    ShowContactMenu();
                    break;

                case "5":
                    DeleteContact();
                    ShowContactMenu();
                    break;

                    case "6":
                
                    ShowContactMenu();
                    break;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}