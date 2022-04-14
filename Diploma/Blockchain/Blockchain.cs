using Diploma.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Blockchain
{
    /// <summary>
    /// Main logic for Blockchain
    /// </summary>
    class Blockchain
    {
        public List<Block> Chain { get; set; }
        public Block CreateGenesisBlock()
        {
            Block genesisBlock = new Block
            {
                BlockId = 0,
                CreatedOn = DateTime.Now.ToUniversalTime(),
                Data = "GENESIS",
                PreviousHash = "GENESIS",
            };
            genesisBlock.Hash = genesisBlock.CreateHash();
            return genesisBlock;
        }

        /// <summary>
        /// Method for check is every block in Chain valid or not defore add a new block in chain
        /// </summary>
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];
                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false;
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
        //TODO
        public void AddBlockToChain()
        {

        }
    }
}