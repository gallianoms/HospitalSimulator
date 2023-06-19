class Hospital
{
    private readonly List<Doctor> doctors;

    public Hospital()
    {
        doctors = new();
    }

    public void AddDoctor()
    {
        Doctor doctor = GetDoctorInformation();
        if (doctor != null)
        {
            doctors.Add(doctor);
            Console.WriteLine("\n *** Doctor added successfully ***");
        }
        else
            Console.WriteLine("\n *** No doctors available ***");

    }

    public void AddPatientToDoctor()
    {
        if (doctors.Count > 0)
        {
            Patient patient = GetPatientInformation();
            doctors.Sort((a, b) => a.Patients.Count.CompareTo(b.Patients.Count));
            Doctor doctorWithFewerPatients = doctors[0];
            doctorWithFewerPatients.Patients.Add(patient);

            Console.WriteLine($"\n *** Patient added successfully to doctor {doctorWithFewerPatients.Name} ***");
        }
        else
            Console.WriteLine("\n *** No doctors available ***");

    }

    public void ListDoctors()
    {
        if (doctors.Count > 0)
        {
            Console.WriteLine("*** List of doctors ***");
            foreach (Doctor doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
        }
        else
            Console.WriteLine("*** No doctors found ***");
    }

    public void ListPeopleInHospital()
    {
        if (doctors.Count > 0)
        {
            foreach (Doctor doctor in doctors)
            {
                if (doctor.Patients.Count > 0)
                {
                    foreach (Patient patient in doctor.Patients)
                        Console.WriteLine(patient);
                }
                else
                    Console.WriteLine("*** No patients available ***");
            }
        }
        else
            Console.WriteLine("*** No doctors available ***");
    }

    public Doctor? FindDoctorByCollegiateNumber(int collegiateNumber)
    {
        foreach (Doctor doctor in doctors)
        {
            if (doctor.CollegiateNumber == collegiateNumber)
                return doctor;
        }
        return null;
    }

    public static Patient GetPatientInformation()
    {
        Console.Write("Enter the name of the patient: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter the gender of the patient (Male, Female, Other): ");
        Person.PersonGender gender = (Person.PersonGender)Enum.Parse(typeof(Person.PersonGender), Console.ReadLine()!);

        Console.Write("Enter the dni of the patient: ");
        string dni = Console.ReadLine()!;

        Console.Write("Enter the address of the patient: ");
        string address = Console.ReadLine()!;

        Console.Write("Enter the phone of the patient: ");
        int phone = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the email of the patient: ");
        string email = Console.ReadLine()!;

        List<string> previousIllnesses = new();
        bool addMoreIllnesses = true;

        while (addMoreIllnesses)
        {
            Console.Write("Enter the previous illness of the patient (write done to finish): ");
            string illness = Console.ReadLine()!;
            if (illness.ToLower() == "done")
                addMoreIllnesses = false;
            else
                previousIllnesses.Add(illness);
        }

        List<string> medicines = new();
        bool addMoreMedicines = true;

        while (addMoreMedicines)
        {
            Console.Write("Enter the medicines of the patient (write done to finish): ");
            string medicine = Console.ReadLine()!;
            if (medicine.ToLower() == "done")
                addMoreMedicines = false;
            else
                medicines.Add(medicine);
        }

        return new Patient(previousIllnesses, medicines, name, gender, dni, address, phone, email);
    }

    public static Doctor GetDoctorInformation()
    {
        Console.Write("Enter the name of the doctor: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter the gender of the doctor (Male, Female, Other): ");
        Person.PersonGender gender = (Person.PersonGender)Enum.Parse(typeof(Person.PersonGender), Console.ReadLine()!);

        Console.Write("Enter the dni of the doctor: ");
        string dni = Console.ReadLine()!;

        Console.Write("Enter the address of the doctor: ");
        string address = Console.ReadLine()!;

        Console.Write("Enter the phone of the doctor: ");
        int phone = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the email of the doctor: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter the doctor collegiate number: ");
        int collegiateNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the doctor experience (Junior, Middle, Senior): ");
        Doctor.DoctorExperience experience = (Doctor.DoctorExperience)Enum.Parse(typeof(Doctor.DoctorExperience), Console.ReadLine()!);

        Console.Write("Enter the doctor specialty (Specialty1, Specialty2, Specialty3): ");
        Doctor.DoctorSpecialty specialty = (Doctor.DoctorSpecialty)Enum.Parse(typeof(Doctor.DoctorSpecialty), Console.ReadLine()!);

        Console.Write("Enter the doctor hospital (Hospital1, Hospital2, Hospital3): ");
        Doctor.DoctorHospital hospital = (Doctor.DoctorHospital)Enum.Parse(typeof(Doctor.DoctorHospital), Console.ReadLine()!);

        Console.Write("Enter the doctor schedule (Morning, Afternoon, Evening): ");
        Doctor.DoctorSchedule schedule = (Doctor.DoctorSchedule)Enum.Parse(typeof(Doctor.DoctorSchedule), Console.ReadLine()!);

        return new Doctor(collegiateNumber, experience, specialty, hospital, schedule, name, gender, dni, address, phone, email);
    }

    public Doctor? GetDoctorByCollegiateNumber()
    {
        Console.Write("Enter the doctor collegiate number: ");
        if (!int.TryParse(Console.ReadLine(), out int collegiateNumber))
        {
            Console.WriteLine("Invalid doctor collegiate number");
            return null;
        }
        Doctor? selectedDoctor = FindDoctorByCollegiateNumber(collegiateNumber);
        return selectedDoctor;

    }
}

