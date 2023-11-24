﻿using System;
class Program{
    static void Main(){
        Console.WriteLine("Nhap vao so hang cua tam giac: ");
        int n;
        // Kiểm tra xem người dùng đã nhập một số nguyên dương hay chưa
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0){
            Console.WriteLine("Vui long nhap vao mot so nguyen duong: ");
        }
        // Gọi hàm để hiển thị tam giác số
        HienThiTamGiacSo(n);
    }
    // Hàm để hiển thị tam giác số
    static void HienThiTamGiacSo(int rows){
        for (int i = 1; i <= rows; i++){
            for (int j = 1; j <= i; j++){
                Console.Write(j + " ");
            }
            Console.WriteLine(); // Xuống dòng sau khi hiển thị xong mỗi hàng
        }
    }
}
