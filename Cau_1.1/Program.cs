using System;
class Program{
    static void Main(){
        Console.WriteLine("Nhap vao mot so nguyen duong n: ");
        int n;
        // Kiểm tra xem người dùng đã nhập một số nguyên dương hay chưa
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0){
            Console.WriteLine("Vui long nhap vao mot so nguyen duong: ");
        }
        // Gọi hàm để tính và hiển thị chữ số thập phân đơn lẻ
        HienThiChuSoLe(n);
    }
    // Hàm để hiển thị chữ số thập phân đơn lẻ của một số nguyên dương
    static void HienThiChuSoLe(int number){
        Console.Write($"Chu so thap phan don le cua {number} la: ");
        while (number > 0){
            int digit = number % 10;
            if (digit % 2 != 0){
                Console.Write($"{digit} ");
            }
            number /= 10;
        }
        Console.WriteLine(); // Xuống dòng sau khi hiển thị xong
    }
}
