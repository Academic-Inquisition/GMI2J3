from to_roman.examples import roman1, roman2, roman3, roman4, roman5, roman6, roman7, roman8, roman9, roman10

program_menu = """
###################################
# Välkommen till Roman Programmen #
###################################
# roman1:   1 #
# roman2:   2 #
# roman3:   3 #
# roman4:   4 #
# roman5:   5 #
# roman6:   6 #
# roman7:   7 #
# roman8:   8 #
# roman9:   9 #
# roman10: 10 #
###############
"""

method_menu = """
#################
# to_roman:   1 #
# from_roman: 2 #
#################
"""


def getOptionNumber(minimum: int, maximum: int, statement: str, error: str):
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


def isInRange(value_in: int, minimum: int, maximum: int):
    return minimum <= value_in <= maximum


if __name__ == '__main__':
    option = -1
    while True:
        print(program_menu)
        value = getOptionNumber(
            1, 10,
            "Please enter which menu choice you'd like!: ",
            "Error: Entered value was in invalid range!"
        )
        print()
        print(method_menu)
        roman_value = getOptionNumber(
            1, 2,
            "Please enter which method choice you'd like!: ",
            "Error: Entered value was in invalid range!"
        )
        match value:
            case 1:
                if roman_value == 1:
                    print(roman1.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print("Error: MethodNotImplemented")
                    pass
            case 2:
                if roman_value == 1:
                    print(roman2.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print("Error: MethodNotImplemented")
                    pass
            case 3:
                if roman_value == 1:
                    print(roman3.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print("Error: MethodNotImplemented")
                    pass
            case 4:
                if roman_value == 1:
                    print(roman4.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print("Error: MethodNotImplemented")
                    pass
            case 5:
                if roman_value == 1:
                    print(roman5.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman5.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case 6:
                if roman_value == 1:
                    print(roman6.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman6.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case 7:
                if roman_value == 1:
                    print(roman7.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman7.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case 8:
                if roman_value == 1:
                    print(roman8.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman8.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case 9:
                if roman_value == 1:
                    print(roman9.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman9.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case 10:
                if roman_value == 1:
                    print(roman10.to_roman(getOptionNumber(
                        1, 1000,
                        "Please enter a number between 1-1000: ",
                        "Error: Entered value was in invalid range!"
                    )))
                    input()
                elif roman_value == 2:
                    print(roman10.from_roman(input("Please enter a roman numeral: ")))
                    input()
            case _:
                break
        option = -1
