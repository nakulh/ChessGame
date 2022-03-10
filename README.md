# ChessGame
## Assumptions regarding token names input:
1. unique names for each token
2. input for token names is in correct format (same as in the pdf)
3. there can only be 1 of each Hero1, Hero2 and Hero3 on one side of the board
4. number of token should not increase the width of the board.
Example - <br>
Correct: H1, H2, P0, P4, H3 <br>
Incorrect: H1, H1, P1, P2, P3 <br>
Incorrect: H1, H1, P1, P2, P3, P4, P5 <br>

Edge cases regarding the move related input is handled, if a player enters an invalid move or try to move an invalid token, then they would be properly prompted
