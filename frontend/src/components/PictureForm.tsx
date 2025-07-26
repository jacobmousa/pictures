import { useRef, useState } from 'react';
import { uploadPicture } from '../api/picturesApi';

export default function PictureForm({ onUpload }: { onUpload: () => void }) {
  const [name, setName] = useState('');
  const [date, setDate] = useState('');
  const [description, setDescription] = useState('');
  const [file, setFile] = useState<File | null>(null);
  const [error, setError] = useState('');
  const fileInputRef = useRef<HTMLInputElement>(null);

    const clearForm = () => {
    setName('');
    setDate('');
    setDescription('');
    setFile(null);
    setError('');
    if (fileInputRef.current) {
      fileInputRef.current.value = '';
    }
  };

  const resetForm = () => {
    if (confirm('Reset form?')) {
      clearForm();
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (!name || !file) {
      setError('Name and file are required.');
      return;
    }

    const formData = new FormData();
    formData.append('Name', name);
    if (date) formData.append('Date', date);
    if (description) formData.append('Description', description);
    formData.append('File', file);

    try {
      await uploadPicture(formData);
      onUpload();
      clearForm();
    } catch (err: any) {
      setError(err.response?.data?.error || 'Upload failed');
    }
  };

  return (
    <form onSubmit={handleSubmit} className="p-4 border rounded bg-light shadow-sm">
      <h4 className="mb-4 text-primary">Add New Picture</h4>

      {error && <div className="alert alert-danger">{error}</div>}

      <div className="mb-3">
        <label className="form-label">Picture Name</label>
        <input className="form-control" type="text" value={name} onChange={e => setName(e.target.value)} required maxLength={50} />
      </div>

      <div className="mb-3">
        <label className="form-label">Date</label>
        <input className="form-control" type="datetime-local" value={date} onChange={e => setDate(e.target.value)} />
      </div>

      <div className="mb-3">
        <label className="form-label">Description</label>
        <textarea className="form-control" value={description} onChange={e => setDescription(e.target.value)} maxLength={250} />
      </div>

      <div className="mb-3">
        <label className="form-label">Image File</label>
        <input ref={fileInputRef} className="form-control" type="file" accept="image/*" onChange={e => setFile(e.target.files?.[0] || null)} required />
      </div>

      <div className="d-flex gap-2">
        <button className="btn btn-success" type="submit">Add Picture</button>
        <button className="btn btn-outline-secondary" type="button" onClick={resetForm}>Reset</button>
      </div>
    </form>
  );
}