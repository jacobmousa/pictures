import { useState } from 'react';
import PictureForm from './components/PictureForm';
import PictureList from './components/PictureList';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const [uploadCount, setUploadCount] = useState(0);

  return (
    <div className="container py-5">
      <h2 className="mb-5 text-center">📷 Picture List</h2>
      <div className="row g-4">
        <div className="col-md-6">
          <PictureList refreshTrigger={uploadCount} />
        </div>
        <div className="col-md-6">
          <PictureForm onUpload={() => setUploadCount(c => c + 1)} />
        </div>
      </div>
    </div>
  );
}

export default App;
