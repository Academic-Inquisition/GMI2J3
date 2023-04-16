# -*- coding: utf-8 -*-
'''
Unit test for leapyear.py
Student version
'''

import unittest
import leapyear as ly


class LeapYearBadInputs(unittest.TestCase):
    def test_leapyear_blank_string(self):
        """to_leap_year should fail with blank string"""
        self.assertRaises(TypeError, ly.to_leap_year, "")

    def test_leapyear_string(self):
        """to_leap_year should fail with invalid string"""
        self.assertRaises(TypeError, ly.to_leap_year, "Hello")

    def test_leapyear_boolean(self):
        """to_leap_year should fail with boolean input"""
        self.assertRaises(TypeError, ly.to_leap_year, True)

    def test_leapyear_float(self):
        """to_leap_year should fail with float input"""
        self.assertRaises(TypeError, ly.to_leap_year, 0.6)

    def test_leapyear_invalid_input(self):
        """to_leap_year should fail with invalid inputs: [0, -5]"""
        self.assertRaises(ValueError, ly.to_leap_year, 0)
        self.assertRaises(ValueError, ly.to_leap_year, -5)


class KnownValues(unittest.TestCase):
    # Established Leap-Years Tests
    def test_leapyear_expected(self):
        print()
        li = [2000, 1904, 2400, 2020, 2010, 1900, 1800, 2002]
        for i in li:
            s = str(i)
            if ly.to_leap_year(i):
                s += " is a leap year"
            else:
                s += " is not a leap year"
            print(s)

    def test_leapyear(self):
        """to_leap_year should give known result with known input"""
        leaps = [1996, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048]
        for i in leaps:
            self.assertTrue(ly.to_leap_year(i), f'Test Failed: Expected that {i} is a leap year!')

    def test_leapyear_invalid(self):
        """to_leap_year should fail with expected non-leap years"""
        nleaps = [1995, 1997, 1999, 2001, 2003, 2005, 2007, 2009, 2011, 2013, 2015, 2017, 2019]
        for i in nleaps:
            self.assertFalse(ly.to_leap_year(i), f'Test Failed: Expected that {i} is not a leap year!')

    # Leap-Years Century-Rule Tests
    def test_leapyear_century(self):
        """to_leap_year should give known result with known input (Century Rule)"""
        leaps = [800, 1200, 1600, 2000]
        for i in leaps:
            self.assertTrue(ly.to_leap_year(i), f'Test Failed: Expected that {i} is a leap year!')

    def test_leapyear_century_invalid(self):
        """to_leap_year should fail with expected non-leap years"""
        nleaps = [1500, 1700, 1800, 1900]
        for i in nleaps:
            self.assertFalse(ly.to_leap_year(i), f'Test Failed: Expected that {i} is not a leap year!')


if __name__ == '__main__': # pragma: no cover
    unittest.main()
