class ShowMenu
{
    private int optionSelected;
    private readonly Hospital hospital;

    public int OptionSelected
    {
        get { return optionSelected; }
        set { optionSelected = value; }
    }

    public enum Menu
    {
        AddDoctor = 1,
        AddPatientToDoctor = 2,
        ListDoctors = 3,
        ListPatients = 4,
        RemovePatient = 5,
        ListPeopleInHospital = 6,
        Exit = 0
    }

    public ShowMenu()
    {
        hospital = new();
    }

    public void Run()
    {
        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("--------- Choose an option: ---------");
            Console.WriteLine("1. Add a doctor");
            Console.WriteLine("2. Add a patient, for a specific doctor");
            Console.WriteLine("3. List the doctors");
            Console.WriteLine("4. List the patients of a doctor");
            Console.WriteLine("5. Remove a patient");
            Console.WriteLine("6. View the list of people present in the hospital");
            Console.WriteLine("0. Exit");
            Console.WriteLine("---------- End menu option ----------\n");

            OptionSelected = Convert.ToInt32(Console.ReadLine());

            Doctor? selectedDoctor;
            switch ((Menu)OptionSelected)
            {
                case Menu.AddDoctor:
                    hospital.AddDoctor();
                    break;
                case Menu.AddPatientToDoctor:
                    hospital.AddPatientToDoctor();
                    break;
                case Menu.ListDoctors:
                    hospital.ListDoctors();
                    break;
                case Menu.ListPatients:
                    selectedDoctor = hospital.GetDoctorByCollegiateNumber()!;
                    if (selectedDoctor != null)
                        selectedDoctor.ListPatients();
                    else
                        Console.WriteLine("Doctor not found");
                    break;
                case Menu.RemovePatient:
                    selectedDoctor = hospital.GetDoctorByCollegiateNumber()!;
                    if (selectedDoctor != null)
                    {
                        Console.WriteLine("Enter the dni of the patient: ");
                        string dni = Console.ReadLine()!;
                        selectedDoctor.RemovePatient(dni);
                    }
                    else
                    { Console.WriteLine("Doctor not found"); }
                    break;
                case Menu.ListPeopleInHospital:
                    hospital.ListPeopleInHospital();
                    break;
                case Menu.Exit:
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        } while ((Menu)OptionSelected != Menu.Exit);
    }


}