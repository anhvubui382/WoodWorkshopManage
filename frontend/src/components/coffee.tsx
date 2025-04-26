import React, { useState, useEffect } from 'react';
import { getCoffeeShopData } from '../services/userService';
interface CoffeeShop {
  id: number;
  title: string;
  price: number;
  description: string;
  image: string;
  ingredients: string[];
  totalSales: number;
}

// Sử dụng interface để chỉ định kiểu dữ liệu của state coffeeShops
export const CoffeeShopList = () => {
  const [coffeeShops, setCoffeeShops] = useState<CoffeeShop[]>([]); // Đảm bảo state có kiểu là mảng CoffeeShop
  const [isLoading, setIsLoading] = useState(true); // Quản lý trạng thái tải dữ liệu
  const [error, setError] = useState<string | null>(null); // Quản lý lỗi

  useEffect(() => {
    const fetchCoffeeShops = async () => {
      try {
        const response = await getCoffeeShopData(); // Gọi API
        setCoffeeShops(response); // Cập nhật state với dữ liệu trả về
        setIsLoading(false); // Đặt trạng thái tải là false sau khi lấy dữ liệu
      } catch (err) {
        setError("Lỗi khi tải dữ liệu quán cà phê."); // Lỗi khi lấy dữ liệu
        setIsLoading(false);
      }
    };

    fetchCoffeeShops(); // Gọi hàm fetch dữ liệu khi component được render lần đầu
  }, []); // Mảng phụ thuộc rỗng có nghĩa là hàm chỉ chạy một lần khi component mount

  if (isLoading) {
    return <div>Đang tải dữ liệu...</div>; // Hiển thị thông báo đang tải dữ liệu
  }

  if (error) {
    return <div>Lỗi: {error}</div>; // Hiển thị thông báo lỗi nếu có
  }

  return (
    <div>
      <h1>Danh sách quán cà phê</h1>
      <ul>
        {coffeeShops.map((shop) => (
          <li key={shop.id}>
            <h2>{shop.title}</h2>
            <img src={shop.image} alt={shop.title} width={200} />
            <p>{shop.description}</p>
            <p><strong>Giá:</strong> ${shop.price}</p>
            <p><strong>Tổng số bán:</strong> {shop.totalSales}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CoffeeShopList;
