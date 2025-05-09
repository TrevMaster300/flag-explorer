import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Home.css';

export default function Home() {
  const [countries, setCountries] = useState([]);
  const [search, setSearch] = useState('');
  const [selectedCountry, setSelectedCountry] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [loading, setLoading] = useState(false);

  // Prevent scroll on background when modal is open
  useEffect(() => {
    document.body.classList.toggle('modal-open', isModalOpen);
    return () => document.body.classList.remove('modal-open');
  }, [isModalOpen]);

  useEffect(() => {
    axios.get('https://localhost:7206/api/Country/countries')
      .then(res => setCountries(res.data))
      .catch(err => console.error('API error:', err));
  }, []);

  const openModal = (name) => {
    setLoading(true);
    setIsModalOpen(true);
    axios.get(`https://localhost:7206/api/Country/countries/${name}`)
      .then(res => {
        setSelectedCountry(res.data);
        setLoading(false);
      })
      .catch(err => {
        console.error('Detail fetch error:', err);
        setLoading(false);
      });
  };

  const closeModal = () => {
    setIsModalOpen(false);
    setSelectedCountry(null);
  };

  const filtered = countries.filter(c =>
    c.name.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="container">
      <h1>🌍 Flag Explorer</h1>
      <input
        className="search-input"
        type="text"
        placeholder="Search countries..."
        value={search}
        onChange={e => setSearch(e.target.value)}
      />

      <div className="flag-grid">
        {filtered.map((c, i) => (
          <div key={i} className="flag-card" onClick={() => openModal(c.name)}>
            <img src={c.flag} alt={c.name} />
            <p>{c.name}</p>
          </div>
        ))}
      </div>

      {isModalOpen && (
        <div className="modal-overlay">
          <div className="modal">
            {loading ? (
              <p>Loading...</p>
            ) : selectedCountry ? (
              <>
                <h2>{selectedCountry.name}</h2>
                <img src={selectedCountry.flag} alt={selectedCountry.name} width={150} />
                <p><strong>Capital:</strong> {selectedCountry.capital}</p>
                <p><strong>Population:</strong> {selectedCountry.population.toLocaleString()}</p>
                <button onClick={closeModal} className="close-button">Close</button>
              </>
            ) : (
              <p>Could not load country details.</p>
            )}
          </div>
        </div>
      )}
    </div>
  );
}
