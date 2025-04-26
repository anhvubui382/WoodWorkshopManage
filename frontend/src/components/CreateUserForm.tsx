// src/components/CreateUserForm.tsx
import { useState } from 'react';
import { createuser, CreateUserRequest } from '../services/userService';

export const CreateUserForm = () => {
  const [formData, setFormData] = useState<CreateUserRequest>({
    username: '',
    password: '',
    email: ''
  });
  const [message, setMessage] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await createuser(formData); // Gọi API tạo người dùng
      setMessage('User created successfully!');
    } catch (err) {
      setMessage('Error creating user');
    }
  };


  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  return (
    <div>
      <h2>Create User</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="username"
          placeholder="Username"
          value={formData.username}
          onChange={handleChange}
        />
        <input
          type="password"
          name="password"
          placeholder="Password"
          value={formData.password}
          onChange={handleChange}
        />
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
        />
        <button type="submit">Create</button>
      </form>
      {message && <p>{message}</p>}
    </div>
  );
};
