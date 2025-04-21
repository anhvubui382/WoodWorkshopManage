FRONTEND/
├── public/
│   ├── index.html
│   └── assets/        <-- Các file tĩnh như hình ảnh, font chữ, v.v.
├── src/
│   ├── api/           <-- Các file gọi API (axios, fetch)
│   │   └── api.js
│   ├── assets/        <-- Các tài nguyên tĩnh (CSS, hình ảnh, icons)
│   ├── components/    <-- Các component tái sử dụng được
│   │   ├── Button.js
│   │   └── Header.js
│   ├── context/       <-- Các context (React Context) cho state management
│   ├── hooks/         <-- Các custom hooks
│   ├── pages/         <-- Các trang ứng dụng (components lớn)
│   │   ├── Home.js
│   │   └── About.js
│   ├── services/      <-- Logic xử lý API, các service liên quan
│   │   └── userService.js
│   ├── store/         <-- Redux store hoặc bất kỳ công cụ quản lý trạng thái nào
│   ├── utils/         <-- Các hàm tiện ích (helpers)
│   ├── App.js         <-- Component chính
│   ├── index.js       <-- Entry point của ứng dụng
│   └── App.css        <-- Các style chính
├── .gitignore         <-- Các tệp cần loại trừ khỏi git
├── package.json       <-- Cấu hình dự án và các phụ thuộc
├── README.md          <-- Tài liệu hướng dẫn sử dụng dự án
└── .eslintrc.json      <-- Cấu hình eslint
