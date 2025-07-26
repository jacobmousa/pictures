import { useEffect, useState } from 'react';
import { getPictures } from '../api/picturesApi';

type Picture = {
  id: number;
  name: string;
};

export default function PictureList({ refreshTrigger }: { refreshTrigger: number }) {
  const [pictures, setPictures] = useState<Picture[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getPictures()
      .then(res => setPictures(res.data))
      .catch(err => {
        console.error("Error fetching pictures:", err);
        setError("Could not load pictures.");
      });
  }, [refreshTrigger]);

  return (
    <div className="p-4 border rounded bg-white shadow-sm">
      <h4 className="mb-4 text-primary">Uploaded Pictures</h4>

      {error && <div className="alert alert-warning">{error}</div>}

      <ul className="list-group">
        {pictures.map(p => (
          <li className="list-group-item d-flex justify-content-between align-items-center" key={p.id}>
            <span>#{p.id}</span>
            <strong>{p.name}</strong>
          </li>
        ))}
      </ul>
    </div>
  );
}
  