
jest.mock('axios', () => ({
  get: jest.fn(() => Promise.resolve({ data: [
    { name: { common: 'Narnia' }, flags: { png: 'narnia.png' } },
    { name: { common: 'Oz'    }, flags: { png: 'oz.png'     } },
  ] })),
}));

import React from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import Home from './Home';

test('Home fetches and displays a grid of flags', async () => {
  render(<Home />);


  expect(screen.getByText(/loading/i)).toBeInTheDocument();

  // wait for the mock data to appear
  await waitFor(() => {
    
    expect(screen.getByAltText('Narnia')).toHaveAttribute('src', 'narnia.png');
    expect(screen.getByAltText('Oz')).toHaveAttribute('src', 'oz.png');
  });
});
