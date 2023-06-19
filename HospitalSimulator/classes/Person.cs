class Person
{
    public enum PersonGender { Male, Female, Other }

    private readonly string name;
    private readonly PersonGender gender;
    private readonly string dni;
    private readonly string address;
    private readonly int phone;
    private readonly string email;

    public string Name { get { return name; } }
    public PersonGender Gender { get { return gender; } }
    public string Dni { get { return dni; } }
    public string Address { get { return address; } }
    public int Phone { get { return phone; } }
    public string Email { get { return email; } }

    public Person(string name, PersonGender gender, string dni, string address, int phone, string email)
    {
        this.name = name;
        this.gender = gender;
        this.dni = dni;
        this.address = address;
        this.phone = phone;
        this.email = email;
    }

    public override string ToString()
    {
        return $"Name: {name}\nGender: {gender}\nDNI: {dni}\nAddress: {address}\nPhone: {phone}\nEmail: {email}\n";
    }
}