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


method_menu = """
#################
# roman:      1 #
# from_roman: 2 #
#################
"""


def getOptionNumber(minimum: int, maximum: int, statement: str, error: str):  # pragma: no cover
    try:
        temp = int(input(statement))
        check = isInRange(temp, minimum, maximum)
        while not check:
            print(error)
            temp = int(input(statement))
            check = isInRange(temp, minimum, maximum)
        return temp
    except ValueError:
        print("Error: Invalid Type, must be a number!")
        pass


def isInRange(value_in: int, minimum: int, maximum: int):  # pragma: no cover
    return minimum <= value_in <= maximum


if __name__ == '__main__':  # pragma: no cover
    while True:
        try:
            value = getOptionNumber(
                0, 1000000,
                statement="Please enter a year to check for 'leap year', must be between 0 and 1000000: ",
                error="Error: Invalid value!"
            )
            if to_leap_year(value):
                value = str(value)
                value += " is a leap year!"

            else:
                value = str(value)
                value += " is not a leap year!"
            print(value)
            input()
        except ValueError as e:
            print(e)
