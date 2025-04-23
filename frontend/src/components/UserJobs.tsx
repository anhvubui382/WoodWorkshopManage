// src/components/UserJobs.tsx
import { useEffect, useState } from 'react';
import { getJobByUserId } from '../services/userService';
import { useParams } from 'react-router-dom';

export const UserJobs = () => {
  const { userId } = useParams<{ userId: string }>(); // Lấy userId từ URL
  const [jobs, setJobs] = useState<any[]>([]);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchJobs = async () => {
      try {
        if (userId) {
          const data = await getJobByUserId(Number(userId)); // Gọi API và truyền userId
          setJobs(data); // Cập nhật jobs từ API
        }
      } catch (err) {
        setError('Could not load jobs for this user'); // Xử lý lỗi
      }
    };

    fetchJobs();
  }, [userId]); // Chạy lại khi userId thay đổi

  return (
    <div>
      <h3>Jobs of User #{userId}</h3>
      {error && <p>{error}</p>}
      <ul>
        {jobs.map((job) => (
          <li key={job.id}>{job.name}</li>
        ))}
      </ul>
    </div>
  );
};
