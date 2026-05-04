# ConnectFour_GroupFour
**CIS-153 Final Group Project:**

The program starts off with the welcome form showing four different options the user can pick from. That being: single player, two player, statistics, and exit. If the user picks single player or two player a number is passed (1 for single player and 2 for two player) to the new game form. If 1 was passed, then the AI is set to active and vice versa. If the user picks statistics a new stats form is loaded which shows a column graph of AI wins, player 1 and 2 wins, and draws. There are also the number of total wins and percentages of wins displayed under the graph. If the user picks to exit, then the program will close.

All statistics for wins and such are stored inside of a text file. All of the data inside of the stats form is retrieved from this file. This file is also updated after each win or draw, keeping the data consistent.

The game board is represented using a Board class that stores a 6 by 7 grid of Cell objects. Each Cell tracks its row, column, piece color, and button reference.

The AI in the single player games uses a rule-based decision system that evaluates the current board and chooses the strongest available move. It analyzes the board in several directions and scores each column based on potential connections, threats, and dangers. It first checks for any immediate winning moves, then blocks potential player threats. After that, it avoids any dangerous columns and chooses the move that creates the strongest future setup. If there are multiple strong moves it will randomly select one of them.

The win detection system scans the entire board after every move and checks each cell for four connected pieces of the same color. It checks for all possible winning directions, that being: horizontal, vertical, negative diagonal, and positive diagonal. If there is a win found, then the function returns the winner. If none were found then it returns zero.

If the user is in two player mode, then after each piece is placed the piece color will switch and the board will be checked for any win states. The user can also see where their piece would land by hovering over the column they wish to place it on (also available in single player mode).

At the end of each match, the user will be taken to the stats form where they will see a label saying who won, and also additional buttons not previously shown before. That being: play again and review. The graph will also now have a green highlight on the column of the winner. For example, if the AI won there would now be a green portion on the column symbolizing their new added win. If the user presses the play again button, a new game form will be loaded with the game type they were just playing. If the user presses review, they will be taken to the board they just completed. They cannot change the board, but can choose to return to the stats form or exit the program from there. Besides the play again button and the review button, the user can also choose to return to the main menu or exit the program.
