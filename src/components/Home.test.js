import React from 'react';
import { render, screen } from '@testing-library/react';
import Home from './Home';

// 1) Tell Jest to use your manual mock
jest.mock('axios');

import axios from 'axios';

test('Home fetches and displays flags', async () => {
  // 2) Seed the mock
  const fakeCountries = [
    { name: { common: 'Narnia' }, flags: { png: 'narnia.png' } },
    { name: { common: 'Oz'      }, flags: { png: 'oz.png'      } },
  ];
  axios.get.mockResolvedValueOnce({ data: fakeCountries });

  // 3) Render the component
  render(<Home />);

  // 4) Assert on the two images showing up
  const narniaImg = await screen.findByAltText('Narnia');
  expect(narniaImg).toHaveAttribute('src', 'narnia.png');

  const ozImg = await screen.findByAltText('Oz');
  expect(ozImg).toHaveAttribute('src', 'oz.png');
});
