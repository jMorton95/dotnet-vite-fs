import { myfunc } from "@/utils/functions";
import {test, expect} from "vitest";

test('add 1 + 2 to equal 3', () => {
  expect(myfunc(1, 2)).toEqual(3);
})

test('add 1 + 0 to equal 1', () => {
  expect(myfunc(1, 0)).toEqual(1);
})

test('add 0 + 1 to equal 1', () => {
  expect(myfunc(0, 1)).toEqual(1);
})

test('add -1 + -1 to equal -2', () => {
  expect(myfunc(-1, -1)).toEqual(-2);
})

test('add 1 + -1 to equal 0', () => {
  expect(myfunc(1, -1)).toBe(0);
})

test('add -1 + 1 does not equal 1', () => {
  expect(myfunc(-1, 1)).not.toEqual(1);
})

test('add 1.23 + 4.77 to equal 6', () => {
  expect(myfunc(1.23, 4.77)).toEqual(6);
})

test('add 1000 + 2000 to equal 3000', () => {
  expect(myfunc(1000, 2000)).toEqual(3000);
})

test('add 1000 + 1500 is not greater than 2500', () => {
  expect(myfunc(1000, 1500)).not.greaterThan(2500);
})