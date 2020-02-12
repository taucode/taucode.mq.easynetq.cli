(defblock :name get-publisher-message-types :is-top t
	(worker
		:worker-name get-publisher-message-types
		:verb "message-types"
		:description "Gets message types supported by the publisher."
		:usage-samples (
			"pub message-types"))

	(end)
)
