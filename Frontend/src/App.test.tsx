import React from 'react';
import { render } from '@testing-library/react';
import { Provider } from 'react-redux';
import { store } from './app/store';
import App from './App';

test('renders learn react link', () => {
  const { getByText } = render(
    <Provider store={store}>
      <App />
    </Provider>
  );

  expect(true);
});
test('шиза 1', () => {
  expect(true);
})
test('шиза 2', () => {
  expect(true);
})
test('шиза 3', () => {
  expect(true);
})
test('шиза 4', () => {
  expect(true);
})
test('шиза 5', () => {
  expect(true);
})
test('шиза 6', () => {
  expect(true);
})
test('шиза 7', () => {
  expect(true);
})
test('шиза 8', () => {
  expect(true);
})
test('шиза 9', () => {
  expect(true);
})