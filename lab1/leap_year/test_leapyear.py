# -*- coding: utf-8 -*-
'''
Unit test for leapyear.py
Student version
'''

import unittest
import leapyear as ly


class LeapYearTypeTests(unittest.TestCase):
    def test_leapyear_type(self):
        # Input-Type Tests
        self.assertRaises(TypeError, ly.to_leap_year, "Hello")
        self.assertRaises(TypeError, ly.to_leap_year, True)
        self.assertRaises(TypeError, ly.to_leap_year, 0.6)

        # Input-Value Tests
        self.assertRaises(ValueError, ly.to_leap_year, 0)
        self.assertRaises(ValueError, ly.to_leap_year, -5)


class LeapYearAssertionTests(unittest.TestCase):
    # Established Leap-Years Tests
    def test_leapyear(self):
        leaps = [1996, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048]
        nleaps = [1995, 1997, 1999, 2001, 2003, 2005, 2007, 2009, 2011, 2013, 2015, 2017, 2019]
        for i in leaps:
            self.assertTrue(ly.to_leap_year(i), f'Test Failed: Expected that {i} is a leap year!')
        for i in nleaps:
            self.assertFalse(ly.to_leap_year(i), f'Test Failed: Expected that {i} is not a leap year!')

    # Leap-Years Century-Rule Tests
    def test_leapyear_century(self):
        leaps = [800, 1200, 1600, 2000]
        nleaps = [1500, 1700, 1800, 1900]
        for i in leaps:
            self.assertTrue(ly.to_leap_year(i), f'Test Failed: Expected that {i} is a leap year!')
        for i in nleaps:
            self.assertFalse(ly.to_leap_year(i), f'Test Failed: Expected that {i} is not a leap year!')


if __name__ == '__main__':
    unittest.main()
