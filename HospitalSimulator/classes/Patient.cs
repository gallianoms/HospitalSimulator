class Patient : Person
{
    private List<string> previousIllnesses;
    private List<string> medicines;

    public List<string> PreviousIllnesses { get { return previousIllnesses; } set { previousIllnesses = value; } }
    public List<string> Medicines { get { return medicines; } set { medicines = value; } }

    public Patient(List<string> previousIllnesses, List<string> medicines, string name, PersonGender gender, string dni, string address, int phone, string email) : base(name, gender, dni, address, phone, email)
    {
        this.previousIllnesses = previousIllnesses;
        this.medicines = medicines;
    }

    public override string ToString()
    {
        string patientData = base.ToString();
        patientData += $"Previous Illnesses: {string.Join(", ", previousIllnesses)}\n";
        patientData += $"Medicines: {string.Join(", ", medicines)}\n";

        return patientData;
    }
}