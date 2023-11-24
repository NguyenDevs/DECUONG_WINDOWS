using System;
class Program{
    static void Main(){
        Console.WriteLine("Nhap vao mot so nguyen co 3 chu so: ");
        int n;
        // Kiểm tra xem người dùng đã nhập một số nguyên có 3 chữ số hay chưa
        while (!int.TryParse(Console.ReadLine(), out n) || n < 100 || n > 999){
            Console.WriteLine("Vui long nhap mot so nguyen co 3 chu so: ");
        }
        // Gọi hàm để tính và hiển thị chữ số đầu tiên và chữ số cuối cùng
        HienThiChuSoDauCuoi(n);
    }
    // Hàm để hiển thị chữ số đầu tiên và chữ số cuối cùng của một số nguyên
    static void HienThiChuSoDauCuoi(int number){
        int chuSoDau = number / 100;
        int chuSoCuoi = number % 10;
        Console.WriteLine($"Chu so dau tien cua {number} la: {chuSoDau}");
        Console.WriteLine($"Chu so cuoi cung cua {number} la: {chuSoCuoi}");
    }
}
