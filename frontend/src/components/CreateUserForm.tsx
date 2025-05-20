// src/components/CreateUserForm.tsx
import React, { useState } from 'react';
import { createuser, CreateUserRequest } from '../services/userService';

export const CreateUserComponent = () => {
  const [formData, setFormData] = useState<CreateUserRequest>({
    username: '',
    password: '',
    email: '',
    fullname: '',
    phone: '',
    address: '',
    detailAddress: 'Thanh Binh Thinh, Ha Tinh, Viet Nam',
  });
  const [rePassword, setRePassword] = useState('');

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (formData.password !== rePassword) {
      alert("Mật khẩu không khớp!");
      return;
    }
    try {
      const result = await createuser(formData);
      alert("Tạo người dùng thành công!");
      console.log("Kết quả:", result);
    } catch (error: any) {
      console.error("Lỗi tạo user:", error.response?.data || error.message);
      alert("Lỗi tạo người dùng. Xem console.");
    }
  };

  return (
    <div className="container mt-5">
      <div className="row">
        <div className="col-6">Mảng đăng nhập</div>
        <div className="col-6">
          <h2 className="mb-4 text-primary">Tạo người dùng</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">
                Tên đăng nhập <span className="text-danger">*</span>
              </label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="username"
                  placeholder="Tên đăng nhập"
                  value={formData.username}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">
                Mật khẩu <span className="text-danger">*</span>
              </label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="password"
                  type="password"
                  placeholder="Mật khẩu"
                  value={formData.password}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">
                Xác nhận mật khẩu<span className="text-danger">*</span>
              </label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="rePassword"
                  type="password"
                  placeholder="Xác nhận mật khẩu"
                  value={rePassword}
                  onChange={(e) => setRePassword(e.target.value)}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">Email<span className="text-danger">*</span></label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="email"
                  placeholder="Email"
                  value={formData.email}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">Số điện thoại<span className="text-danger">*</span></label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="phone"
                  placeholder="Số điện thoại"
                  value={formData.phone}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">Họ tên<span className="text-danger">*</span></label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="fullname"
                  placeholder="Họ tên"
                  value={formData.fullname}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="mb-3 row align-items-center">
              <label className="col-sm-3 col-form-label">Địa chỉ<span className="text-danger">*</span></label>
              <div className="col-sm-9">
                <input
                  className="form-control"
                  name="address"
                  placeholder="Địa chỉ"
                  value={formData.address}
                  onChange={handleChange}
                  required
                />
              </div>
            </div>

            <div className="text-center">
              <button type="submit" className="btn btn-danger">
                Đăng ký
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};
