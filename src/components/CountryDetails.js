import React from 'react';

export default function CountryDetails({ country }) {
  if (!country) return null;

  return (
    <div style={{ marginTop: '30px', textAlign: 'center' }}>
      <h2>{country.name}</h2>
      <img src={country.flag} alt={country.name} width="150" />
      <p><strong>Capital:</strong> {country.capital}</p>
      <p><strong>Population:</strong> {country.population.toLocaleString()}</p>
    </div>
  );
}
