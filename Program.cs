namespace Ass_2{
    class Program{
        static List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 22),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };


        static void Main(string[] args){
            //1.Return a list of members who is male
            // var maleMembers = GetMaleMembers();
            // PrintData(maleMembers);

            //2.Get Oldest Member
            // var oldestMembers = GetOldestMember();
            // PrintData(new List<Member>{oldestMembers});

            //3.Get Full Name Member
            // var fullnames = GetFullName();
            // for (int i = 0; i < fullnames.Count; i++)
            // {
            //     string? fullname = fullnames[i];
            //     Console.WriteLine($"{i+1}.{fullname}");
            // }

            //4.Split members by year
            // var results = SplitMemberByBirthYear();
            // PrintData(results.Item1);
            // Console.WriteLine("-----------------------");
            // PrintData(results.Item2);
            // Console.WriteLine("-----------------------");
            // PrintData(results.Item3);
            // Console.WriteLine("-----------------------");

            //5.The first member in Ha Noi
            var placeMember = GetMemberByBirthPlace("ha noi ");
            if(placeMember != null){
                PrintData(new List<Member>{placeMember});
            }
            else{
                Console.WriteLine("No Data.");
            }
            

        }
        static void PrintData(List<Member> data){
            var index = 0 ;
            foreach(var item in data){
                ++index;
                Console.WriteLine($"{index}.{item.LastName} {item.FirstName} - {item.DateOfBirth.ToString("dd/MM/yyyy")} - {item.Age} ");
            }
        }
        static List<Member> GetMaleMembers(){
            // var result = members.Where(x => x.Gender == "Male").ToList();

            // var result = members.Select((member,index) =>
            // {
            //     if (member.Gender == "Male"){
            //         return member;
            //     }
            //     else 
            //         return null;
            // }).Where(x => x!=null).ToList();

            var result = (from member in members
                        where member.Gender == "Male"
                        select member).ToList();
            return result;
        }
        static Member GetOldestMember(){
            // var maxAge = members.Max(x => x.Age);
            // Console.WriteLine($"Max Age : {maxAge}");
            // return members.First(m =>m.Age == maxAge);

            // return members.OrderByDescending(m => m.Age).First();

            var orderList = from member in members
                            orderby member.Age descending
                            select member;
            return orderList.First();
        }
        
        static List<string> GetFullName(){
            var fullname = members.Select(m => m.FullName);
            return fullname.ToList();
        }
        static Tuple<List<Member>,List<Member>,List<Member>> SplitMemberByBirthYear(){
            var list1 = members.Where(m => m.DateOfBirth.Year == 2000).ToList();
            var list2 = members.Where(m => m.DateOfBirth.Year < 2000).ToList();
            var list3 = members.Where(m => m.DateOfBirth.Year > 2000).ToList();

            

            return Tuple.Create(list1,list2,list3);
            
        }
        static Member? GetMemberByBirthPlace(string place){
            return members.FirstOrDefault(m => m.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase));
        }
        
    }
}
