class Doctor : Person
{
    public enum DoctorExperience { Junior, Middle, Senior }
    public enum DoctorSpecialty { Specialty1, Specialty2, Specialty3 }
    public enum DoctorSchedule { Morning, Afternoon, Evening }
    public enum DoctorHospital { Hospital1, Hospital2, Hospital3 }

    private readonly int collegiateNumber;
    private readonly DoctorExperience experience;
    private readonly DoctorSpecialty specialty;
    private readonly DoctorHospital hospital;
    private readonly DoctorSchedule schedule;

    List<Patient> patients;

    public int CollegiateNumber { get { return collegiateNumber; } }
    public DoctorExperience Experience { get { return experience; } }
    public DoctorSpecialty Specialty { get { return specialty; } }
    public DoctorHospital Hospital { get { return hospital; } }
    public DoctorSchedule Schedule { get { return schedule; } }
    public List<Patient> Patients { get { return patients; } set { patients = value; } }

    public Doctor(int collegiateNumber, DoctorExperience experience, DoctorSpecialty specialty, DoctorHospital hospital, DoctorSchedule schedule, string name, PersonGender gender, string dni, string address, int phone, string email) : base(name, gender, dni, address, phone, email)
    {
        this.collegiateNumber = collegiateNumber;
        this.experience = experience;
        this.specialty = specialty;
        this.hospital = hospital;
        this.schedule = schedule;

        patients = new();
    }

    public override string ToString()
    {
        string baseString = base.ToString();
        string doctorString = $"Collegiate Number: {collegiateNumber}\n" +
                              $"Experience: {experience}\n" +
                              $"Specialty: {specialty}\n" +
                              $"Hospital: {hospital}\n" +
                              $"Schedule: {schedule}\n";

        return baseString + doctorString;
    }

    public void ListPatients()
    {
        if (patients.Count > 0)
        {
            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient);
            }
        }
        else
            Console.WriteLine("\n *** No patients ***");
    }

    public void RemovePatient(string dni)
    {
        int initialCount = patients.Count;
        patients.RemoveAll(patient => patient.Dni == dni);

        if (patients.Count < initialCount)
            Console.WriteLine("\n *** Patient removed successfully ***");
        else
            Console.WriteLine("\n *** Patient not found ***");
    }
}