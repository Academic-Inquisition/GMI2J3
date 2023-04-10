# -*- coding: utf-8 -*-
import sys

"""
There is a leap year every year whose number is perfectly divisible by four - 
except for years which are both divisible by 100 and not divisible by 400. 
The second part of the rule effects century years. 
For example; the century years 1600 and 2000 are leap years, 
but the century years 1700, 1800, and 1900 are not.
"""


def to_leap_year(year):
    if not type(year) == int:
        raise TypeError(f'Year is not of type Integer, Type:{type(year)}')
    if year <= 0:
        raise ValueError(f'Year is outside of expected bounds, should be between 1 and max integer size!, Size: {year}')
    return year % 4 == 0 and not (year % 100 == 0 and not year % 400 == 0)


if __name__ == '__main__':
    print(to_leap_year(1600))
    print(to_leap_year(1700))
    print(to_leap_year(1800))
    print(to_leap_year(1900))
    print(to_leap_year(2000))
    print(to_leap_year(2021))
    print(to_leap_year(2024))
